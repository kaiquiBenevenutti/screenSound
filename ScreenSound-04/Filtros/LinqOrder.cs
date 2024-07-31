using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenSound_04.Modelos;

namespace ScreenSound_04.Filtros
{
    internal class LinqOrder
    {
        public static void ExibirListaDeArtistasOrdenados(List<Musica> musicas)
        {
            var artistasOrdenados = musicas.
                OrderBy(musicas => musicas.Artista)
                .Select(musicas => musicas.Artista)
                .Distinct()
                .ToList();
            Console.WriteLine("Lista de artistas ordenados");
            foreach (var artista in artistasOrdenados)
            {
                Console.WriteLine("- " + artista);
            }
        }
    }
}
