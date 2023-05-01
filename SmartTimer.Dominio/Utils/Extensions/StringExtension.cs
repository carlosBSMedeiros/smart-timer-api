using SmartTimer.Dominio.Utils.Excecoes;

namespace SmartTimer.Dominio.Utils.Extensions
{
    public static class StringExtension
    {
        public static void VerificarAtributo(this string valor, string atributo)
        {
            if (string.IsNullOrEmpty(valor))
            {
                throw new AtributoObrigatorioExcecao(atributo);
            }
        }
    }
}
