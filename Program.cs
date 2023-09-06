using fluent_validation_pattern;

var peterParker = new Cliente("Peter Benjamin Parker", "peter.parker@marvel.com", 23);

Print(peterParker);

peterParker.EditarNome("");
peterParker.EditarEmail("peter.parker@");
peterParker.EditarIdade(17);

Print(peterParker);

static void Print(Cliente cliente)
{
    var resultValidate = cliente.Validate(cliente);

    Console.ForegroundColor = ConsoleColor.Magenta;

    if (resultValidate.IsValid)
    {
        Console.WriteLine("\nCliente válido:");
        Console.WriteLine("===============");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Id: {cliente.Id} - Nome: {cliente.Nome} - e-mail: {cliente.Email} - Idade: {cliente.Idade}");
    }
    else
    {
        Console.WriteLine("\nCliente inválido:");
        Console.WriteLine("=================");

        Console.ForegroundColor = ConsoleColor.Red;
        foreach (var error in resultValidate.Errors)
        {
            Console.WriteLine(error.ErrorMessage);
        }
    }
}
