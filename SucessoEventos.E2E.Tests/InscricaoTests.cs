namespace SucessoEventos.E2E.Tests;

using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class InscricaoTests : PageTest
{
    [Test]
    public async Task MyTest()
    {
        await Page.GotoAsync("http://100.99.124.44:5040/");
        await Page.GetByLabel("Nome").ClickAsync();
        await Page.GetByLabel("Nome").FillAsync("Test");
        await Page.GetByLabel("Nome").PressAsync("ControlOrMeta+a");
        await Page.GetByLabel("Nome").FillAsync("Fulano");
        await Page.GetByLabel("Nome").PressAsync("Tab");
        await Page.GetByLabel("DataNascimento").FillAsync("01/04/2000");
        await Page.GetByLabel("DataNascimento").PressAsync("Tab");
        await Page.GetByLabel("Telefone").FillAsync("1194019957");
        await Page.GetByLabel("Telefone").PressAsync("Tab");
        await Page.GetByRole(AriaRole.Main).Locator("div").Filter(new() { HasText = "PacoteId Selecione um PacoteS" }).GetByRole(AriaRole.Textbox).ClickAsync();
        await Page.Locator("span").Filter(new() { HasTextRegex = new Regex("^Sócio$") }).ClickAsync();
        await Page.GetByLabel("Nome").ClickAsync();
        await Page.GetByLabel("DataNascimento").ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "4", Exact = true }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Ok" }).ClickAsync();
        await Page.GetByLabel("Telefone").ClickAsync();
        await Page.GetByRole(AriaRole.Main).Locator("div").Filter(new() { HasText = "Atividades Workshop de C#" }).GetByRole(AriaRole.Textbox).ClickAsync();
        await Page.Locator("span").Filter(new() { HasText = "Workshop de C# Avançado" }).First.ClickAsync();
        await Page.Locator("#select-options-1669dc38-0501-9709-e59a-eab40e0ecdd72").GetByText("Hackathon de 24 horas").ClickAsync();
        await Page.GetByRole(AriaRole.Main).Locator("div").Filter(new() { HasText = "PacoteId Selecione um PacoteS" }).GetByRole(AriaRole.Textbox).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Próximo" }).ClickAsync();
        await Page.GetByText("Hackathon de 24 horas (¤200.").ClickAsync();
        await Page.GetByText("Workshop de C# Avançado (¤150").ClickAsync();
        await Page.GetByText("Sócio").ClickAsync();
        await Page.GetByText("1194019957").ClickAsync();
        await Page.GetByText("04/01/").ClickAsync();
        await Page.GetByText("Fulano").ClickAsync();
        await Page.GetByText("Nome").ClickAsync();
        await Page.GetByText("Data de Nascimento").ClickAsync();
        await Page.GetByText("Telefone").ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Confirmar Inscrição" }).ClickAsync();
    }
}

