namespace App1.Services
{
    public static class Api
    {
        public static bool GetLogin(string email, string senha)
        {
            return true;
        }

        public static Models.RootEspecie GetEspecies()
        {            
            return null;
        }

        public static Models.RootArvore GetArvores()
        {
            return null;
        }

        public static bool PostArvore(Models.Arvore value)
        {
            return true;    
        }
    }
}
