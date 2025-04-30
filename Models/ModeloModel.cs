namespace AppModelos.Models
{
    public class ModeloModel
    {
        public ModeloModel(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
            Id = Guid.NewGuid();
            Ativo = true;

        }

        public Guid Id { get; init; }
        public string? Descricao { get; private set; }
        public string? Titulo { get; private set; }
        public Boolean Ativo { get; private set; }

        public void MudaTitulo(string titulo)
        {
            Titulo = titulo;
        }

        public void MudaDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void DesativaModelo()
        {
            Ativo = false;
        }

    }
}
