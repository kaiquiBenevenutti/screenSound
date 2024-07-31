using System.Text.Json.Serialization;
namespace ScreenSound_04.Modelos
{
    internal class Musica
    {
        [JsonPropertyName("song")]
        public string? Nome { get; set; }
        [JsonPropertyName("artist")]
        public string? Artista { get; set; }
        [JsonPropertyName("duration_ms")]
        public int? Duracao { get; set; }
        [JsonPropertyName("genre")]
        public string? Genero { get; set; }

        public void ExibirDetalhesDaMusica()
        {
            Console.WriteLine("Artista: " + Artista);
            Console.WriteLine("Múisica: " + Nome);
            Console.WriteLine("Duração: " + (Duracao / 1000));
            Console.WriteLine("Genero: " + Genero);
        }

        public void ExibirDetalhesDaMusica(string genero)
        {
            this.Genero = genero;
            Console.WriteLine("Genero: " + Genero);
        }
    }
}
