namespace EntityFrameworkCore.GenericRepository.Exceptions
{
    public class ObjectNotFoundException : System.Exception
    {
        public ObjectNotFoundException() { }
        public ObjectNotFoundException( string message ) : base( message ) { }
        public ObjectNotFoundException( string message, System.Exception inner ) : base( message, inner ) { }
       
    }
}