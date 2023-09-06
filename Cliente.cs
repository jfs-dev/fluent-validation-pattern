using FluentValidation;

namespace fluent_validation_pattern;

public class Cliente : AbstractValidator<Cliente>
{
    public Cliente(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;

        RegistrarRules();
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public int Idade { get; private set; }

    public void EditarNome(string nome)
    {
        Nome = nome;
    }

    public void EditarEmail(string email)
    {
        Email = email;
    }

    public void EditarIdade(int idade)
    {
        Idade = idade;
    }

    private void RegistrarRules()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Favor informar o nome do cliente!")
            .MaximumLength(50).WithMessage("O nome do cliente não pode ter mais de 50 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Favor informar um e-mail!")
            .EmailAddress().WithMessage("Favor informar um e-mail válido!");

        RuleFor(x => x.Idade)
            .GreaterThanOrEqualTo(18).WithMessage("O cliente deve ser maior de 18 anos!");
    }
}
