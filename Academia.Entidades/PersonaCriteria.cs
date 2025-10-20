namespace Academia.Entidades
{
    public class PersonaCriteria
    {
        public string Texto { get; private set; }

        public PersonaCriteria(string texto)
        {
            Texto = texto.Trim();
        }
    }
}
