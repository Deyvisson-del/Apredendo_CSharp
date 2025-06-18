class Pessoa
{
    public string nome { get; set;}
    public int idade { get; set;}
    public double altura { get; set; }

    public Pessoa(string nome, int idade, double altura)
    {
        this.nome = nome;
        this.idade = idade;
        this.altura = altura;
    }

    public override string ToString()
    {
        return $"Nome: {nome}, Idade: {idade}, Altura: {altura}";
    }

    public string GetNome()
    {
        return nome;
    }
    public int GetIdade()
    {
        return idade;
    }
    public double GetAltura()
    {
        return altura;
    }

    public void SetNome(string nome)
    {
        this.nome = nome;
    }
    public void SetIdade(int idade)
    {
        this.idade = idade;
    }
    public void SetAltura(double altura)
    {
        this.altura = altura;
    }

    List<Pessoa> pessoas = new List<Pessoa>();

    public void AdicionarPessoa(string nome, int idade, double altura)
    {
        if (string.IsNullOrEmpty(nome) || idade < 0 || altura <= 0)
        {
            throw new ArgumentException("\nDados inválidos para a pessoa.");
        }

        pessoas.Add(new Pessoa(nome, idade, altura));
    }



    public Pessoa VisualizarPessoa()
    {
        if (pessoas.Count == 0)
        {
            throw new InvalidOperationException("\nNenhuma pessoa cadastrada.");
        }
        return pessoas[0];
    }

    public List<Pessoa> PesquisarPorNome(string nome)
    {
        List<Pessoa> resultado = new List<Pessoa>();

        foreach (var pessoa in pessoas)
        {
            if (pessoa.GetNome().Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                resultado = pessoas.FindAll(p => p.GetNome().Equals(nome, StringComparison.OrdinalIgnoreCase));
            }
        }
        return resultado;
    }

    public void DeletarPessoa(string nome)
    {
        Pessoa pessoaParaRemover = pessoas.Find(p => p.GetNome().Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (pessoaParaRemover != null)
        {
            pessoas.Remove(pessoaParaRemover);
            Console.WriteLine($"\nPessoa {nome} removida com sucesso.");
        }
        else
        {
            Console.WriteLine($"\nPessoa {nome} não encontrada.");
        }
    }

    public void menu()
    {
        do
        {
            Console.WriteLine("Menu de opções:");
            Console.WriteLine("1. Cadastrar pessoa");
            Console.WriteLine("2. Visualizar pessoa");
            Console.WriteLine("3. Deletar pessoa");
            Console.WriteLine("4. Pesquisar por nome");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    
                    Console.WriteLine("\nCadastro de pessoa:");       
                    Console.Write("Digite o nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite a idade: ");
                    int idade = int.Parse(Console.ReadLine());
                    Console.Write("Digite a altura: ");
                    double altura = double.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                    AdicionarPessoa(nome, idade, altura);
                    break;
                case "2":
                    try
                    {
                        Pessoa p = VisualizarPessoa();
                        Console.WriteLine(p);
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "3":
                    string nomeDeletar;
                    Console.WriteLine("\nDigite o nome da pessoa que deseja deletar:");
                    nomeDeletar = Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("\nDigite o nome da pessoa que deseja pesquisar:");
                    string nomePesquisa = Console.ReadLine();
                    PesquisarPorNome(nomePesquisa);
                    break;

                case "5":
                    Console.WriteLine("\nSaindo do sistema...");
                    return;
                default:
                    Console.WriteLine("\nOpção inválida. Tente novamente.");
                    break;
            }
        } while (true);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao sistema de cadastro de pessoas!");
        Pessoa pessoa = new Pessoa("", 0, 0.0);
        pessoa.menu();
    }
}