using System.Text.Json;
using ScreenSound_04.Modelos;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ScreenSound_04.Filtros;

Console.ForegroundColor = ConsoleColor.Green;
Console.ResetColor();

using (HttpClient client = new HttpClient())
{

    while (true)
    {


        try
        {
            string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
            var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

            Console.Write("Ola, voce deseja filtrar por artista, genero, tonalidade ou  nenhum?(a/g/t/n): ");
            string entrada = Console.ReadLine();
            Console.Clear();

            if (string.IsNullOrEmpty(entrada) || entrada.Length != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada inválida. Por favor, insira 'a' para artista, 'g' para gênero, ou 'n' para nenhum.");
                Console.ResetColor();
                continue;
            }

            char filtro = entrada[0];

            switch (filtro)
            {
                case 'a':
                case 'A':

                    Console.Write("Insira um artista: ");
                    string artistaDesejado = Console.ReadLine();

                    var musicasFiltradasOrdenadasPorArtista = musicas
                        .Where(m => m.Artista.Equals(artistaDesejado, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(m => m.Artista)
                        .ToList();

                    foreach (var item in musicasFiltradasOrdenadasPorArtista)
                    {
                        item.ExibirDetalhesDaMusica();
                        Console.WriteLine();
                    }

                    Console.WriteLine("\nLista com " + musicasFiltradasOrdenadasPorArtista.Count + " musicas do artista: " + artistaDesejado);

                    break;

                case 'g':
                case 'G':

                    Console.Write("Insira um genero: ");
                    string generoDesejado = Console.ReadLine();

                    var musicasFiltradasOrdenadasPorGenero = musicas
                        .Where(m => m.Genero.Equals(generoDesejado, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(m => m.Artista)
                        .ToList();

                    foreach (var item in musicasFiltradasOrdenadasPorGenero)
                    {
                        item.ExibirDetalhesDaMusica();
                        Console.WriteLine();
                    }

                    Console.WriteLine("\nLista com " + musicasFiltradasOrdenadasPorGenero.Count + " musicas do genero: " + generoDesejado);

                    break;

                case 't':
                case 'T':

                    LinqFilter.FiltrarMusicasEmCSharp(musicas);

                    

                    break;

                case 'n':
                case 'N':

                    foreach (var item in musicas)
                    {
                        item.ExibirDetalhesDaMusica();
                        Console.WriteLine();
                    }
                    Console.WriteLine("O total de " + musicas.Count + " musicas");

                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida. Por favor, insira 'a', 'g' ou 'n'.");
                    Console.ResetColor();
                    break;
            }

        }

        catch (Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("!!!Insira uma das opções abaixo(a/g/n)!!!");
            Console.WriteLine();
            Console.ResetColor();

        }

        Console.Write("\nDeseja fazer outra consulta? (s/n): ");
        string continuar = Console.ReadLine();
        if (continuar?.Trim().ToLower() != "s")
        {
            break;
        }
        else
        {
            Console.Clear();
        }
    }

    #region !!!PARTE DA AULA DO CURSO!!!

    //try
    //{
    //    string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
    //    var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

    //    LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
    //    LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
    //    Console.WriteLine();
    //    LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
    //    string msc = Console.ReadLine();
    //    LinqFilter.FiltrarMusicasDeUmArtista(musicas, msc);
    //    Console.WriteLine();

    //    //var musicasPreferidasDoKaiqui = new MusicasPreferidas("Kaiqui");

    //    //musicasPreferidasDoKaiqui.AdicionarMusicasFavoritas(musicas[1]);
    //    //musicasPreferidasDoKaiqui.AdicionarMusicasFavoritas(musicas[377]);
    //    //musicasPreferidasDoKaiqui.AdicionarMusicasFavoritas(musicas[4]);
    //    //musicasPreferidasDoKaiqui.AdicionarMusicasFavoritas(musicas[6]);
    //    //musicasPreferidasDoKaiqui.AdicionarMusicasFavoritas(musicas[1467]);

    //    //musicasPreferidasDoKaiqui.ExibirMusicasFavoritas();

    //    //musicasPreferidasDoKaiqui.GerarArquivoJson();

    //    //var musicasPreferidasDaKati = new MusicasPreferidas("Kati");

    //    //musicasPreferidasDaKati.AdicionarMusicasFavoritas(musicas[356]);
    //    //musicasPreferidasDaKati.AdicionarMusicasFavoritas(musicas[1357]);
    //    //musicasPreferidasDaKati.AdicionarMusicasFavoritas(musicas[1997]);
    //    //musicasPreferidasDaKati.AdicionarMusicasFavoritas(musicas[6]);
    //    //musicasPreferidasDaKati.AdicionarMusicasFavoritas(musicas[174]);

    //    //musicasPreferidasDaKati.ExibirMusicasFavoritas();
    //}
    //catch (Exception ex)
    //{
    //    Console.WriteLine(ex.Message);
    //}

    #endregion

}