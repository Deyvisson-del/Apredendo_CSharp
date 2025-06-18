class Pessoa
{
    string nome;
    int idade;
    double altura;

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
            throw new ArgumentException("Dados inválidos para a pessoa.");
        }

        pessoas.Add(new Pessoa(nome, idade, altura));
    }



    public Pessoa VisualizarPessoa()
    {
        if (pessoas.Count == 0)
        {
            throw new InvalidOperationException("Nenhuma pessoa cadastrada.");
        }
        return pessoas[0];
    }

    public List<Pessoa> PesquisarPorNome(string nome)
    {
        List<Pessoa> resultado = new List<Pessoa>();

        Console.WriteLine("Digite o nome da pessoa que deseja pesquisar:");
        foreach (var pessoa in pessoas)
        {
            if (pessoa.GetNome().Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                resultado.Add(pessoa);
            }
        }
        return resultado;
    }

    public void menu()
    {
        do
        {
            Console.WriteLine("Menu de opções:");
            Console.WriteLine("1. Cadastrar pessoa");
            Console.WriteLine("2. Visualizar pessoa");
            Console.WriteLine("3. Sair");
            Console.WriteLine("4. Pesquisar por nome");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite a idade: ");
                    int idade = int.Parse(Console.ReadLine());
                    Console.Write("Digite a altura: ");
                    double altura = double.Parse(Console.ReadLine());
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
                    Console.WriteLine("Saindo do sistema...");
                    return;
                case "4":
                    string nomePesquisa = Console.ReadLine();
                    PesquisarPorNome(nomePesquisa);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
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
