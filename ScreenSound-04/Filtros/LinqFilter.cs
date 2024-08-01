using System.Linq;
using ScreenSound_04.Modelos;

namespace ScreenSound_04.Filtros
{
    internal class LinqFilter
    {
        public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
        {
            var todosOsGenerosMusicais = musicas.Select(g =>
            g.Genero).Distinct().ToList();

            foreach (var genero in todosOsGenerosMusicais)
            {
                Console.WriteLine("- " + genero);
            }
        }

        public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas,
            string genero)
        {
            var artistasPorGeneroMusical = musicas.Where(musicas => musicas.Genero.Contains(genero))
                .Select(musicas => musicas.Artista)
                .Distinct()
                .ToList();

            Console.WriteLine("Exibindo os artistas por gênero musical >>> " + genero);
            foreach (var artista in artistasPorGeneroMusical)
            {
                Console.WriteLine("- " + artista);
            }
        }

        public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeDoArtista)
        {
            var musicasDoArtista = musicas.Where(m => m.Artista!.Equals(nomeDoArtista))
                .ToList();

            Console.WriteLine(nomeDoArtista);
            foreach (var musica in musicasDoArtista) {
                Console.WriteLine("- " + musica.Nome);
            }
        }

        internal static void FiltrarMusicasEmCSharp(List<Musica> musicas)
        {
            var musicasEmCSharp = musicas.Where(m => m.Tonalidade.Equals("C#"))
                .Select(m => m.Nome)
                .ToList();

            Console.WriteLine("Musicas em C#:");

            foreach (var item in musicasEmCSharp)
            {
                Console.WriteLine("- " + item);
            }
        }
    }
}
