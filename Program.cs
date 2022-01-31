using System; 
using Dio.Series;

namespace Dio.Series 
{
   public enum Genero{}
    class program 
    { 
        static SerieRepositorio Repositorio = new SerieRepositorio();
        static void Main(string [] args) 
        { 
            string opcaoUsuario = ObterOpcaoUsuario();


			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
   					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					
					case "5":
						VisualizarSerie();
						break;
					
					case "C":
						Console.Clear();
						break; 

					default:
						throw new ArgumentOutOfRangeException();
				}

			
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

       
	   //1 metodo Listar Serie 
	    private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = Repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				Console.ReadKey();   
				return; 

			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
		
		// 2 -metodo inserir Serie 
		 private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: Repositorio.ProximoId(),
				genero: (Genero)entradaGenero,
				titulo: entradaTitulo,
				ano: entradaAno,
				descricao: entradaDescricao);

			Repositorio.Insere(novaSerie);
		}

        //3 metodo Atualizar serie 
		private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
				genero: (Genero)entradaGenero,
				titulo: entradaTitulo,
				ano: entradaAno,
				descricao: entradaDescricao);

			Repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

		//4 metodo  Excluir serie 
		private static void ExcluirSerie()
		{
		 System.Console.WriteLine("Digite o id da série" );
		 int indiceSerie = int.Parse(Console.ReadLine()); 
		 
		 Repositorio.Exclui(indiceSerie); 
		
		}

		//5 Metodo Visualizar serie 
		private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = Repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie); 
		}


		//Obter Usuario 
		 private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
          

	


    }
}