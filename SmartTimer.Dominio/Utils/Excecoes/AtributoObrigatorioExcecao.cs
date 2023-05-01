using System.Runtime.Serialization;

namespace SmartTimer.Dominio.Utils.Excecoes
{
    public class AtributoObrigatorioExcecao : RegraDeNegocioExcecao
    {
        public AtributoObrigatorioExcecao() : base("Atributo obrigatório")
        { }

        public AtributoObrigatorioExcecao(string atributo) : base($"Atributo {atributo} é obrigatório")
        { }
    }
}
