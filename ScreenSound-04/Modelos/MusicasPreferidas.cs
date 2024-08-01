using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ScreenSound_04.Modelos
{
    internal class MusicasPreferidas
    {
        public string Nome { get; set; }
        public List<Musica> listaDeMusicasFavoritas { get; }

        public MusicasPreferidas(string nome)
        {
            Nome = nome;
            listaDeMusicasFavoritas = new List<Musica>();
        }

        public void AdicionarMusicasFavoritas(Musica musica)
        {
            listaDeMusicasFavoritas.Add(musica);
        }

        public void ExibirMusicasFavoritas()
        {
            Console.WriteLine("Essas são as musicas favoritas -> " + Nome);
            foreach (var musica in listaDeMusicasFavoritas)
            {
                Console.WriteLine("- " + musica.Nome + " de "+ musica.Artista);
            }
            Console.WriteLine();
        }

        public void GerarArquivoJson()
        {
            string json = JsonSerializer.Serialize(new
            {
                nome = Nome,
                musicas = listaDeMusicasFavoritas
            });
            string nomedoArquivo = "musicas-favoritas-" + Nome + ".json";

            File.WriteAllText(nomedoArquivo, json);
            Console.WriteLine("O arquivo json foi criado com sucesso!" + Path.GetFullPath(nomedoArquivo));
        }
    }
}
