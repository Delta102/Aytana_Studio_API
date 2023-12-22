using AM_Api.DataAccess;
using AM_Api.Helpers;
using AM_Api.Models.Worker;
using static AM_Api.Services.WorkersService;

namespace AM_Api.Services
{
    public interface IWorkersService
    {
        RegisterResult Register(string email, string name, string lastName, string password);
        bool EmailExists(string email);
        Workers Login(string username, string password);
        List<Workers> GetAllWorkers();
    }
    public class WorkersService : IWorkersService
    {
        public readonly ContextDB _context;
        // CONSTRUCTOR
        public WorkersService(ContextDB context) {  
            _context = context; 
        }

        // FUNCTIONS
        public bool EmailExists(string email)
        {
            return _context.Workers.Any(data => data.Email == email);
        }

        public class RegisterResult
        {
            public bool IsRegistered { get; set; }
            public string Message { get; set; } = "";
        }

        public RegisterResult Register(string email, string name, string lastName, string password)
        {
            bool emailExists = EmailExists(email);

            if (emailExists)
            {
                return new RegisterResult
                {
                    IsRegistered = false,
                    Message = "Lo sentimos, el email ya fue registrado"
                };
            }

            var encryption = HelperCryptography.GenerateSalt();

            var worker = new Workers
            {
                Email = email,
                Name = name,
                LastName = lastName,
                Cifrado = encryption,
                Password = HelperCryptography.EncryptPassword(password, encryption),
            };

            _context.Workers.Add(worker);
            _context.SaveChanges();

            return new RegisterResult { IsRegistered = true, Message = "Registro realizado con éxito" };
        }

        public Workers Login(string email, string password)
        {
            Workers worker = _context.Workers.SingleOrDefault(x => x.Email == email);
            if (worker == null)
                return null;
            
            else
            {
                //Debemos comparar con la base de datos el password haciendo de nuevo el cifrado con cada salt de usuario
                byte[] passWorker = worker.Password;
                string salt = worker.Cifrado;
                //Ciframos de nuevo para comparar
                byte[] temp = HelperCryptography.EncryptPassword(password, salt);

                //Comparamos los arrays para comprobar si el cifrado es el mismo
                bool response = HelperCryptography.compareArrays(passWorker, temp);
                if (response == true)
                    return worker;
                else
                {
                    return null;
                }
            }
        }

        public List<Workers> GetAllWorkers()
        {
            return _context.Workers.ToList();
        }
    }
}