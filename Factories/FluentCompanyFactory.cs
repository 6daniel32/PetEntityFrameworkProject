public class FluentCompanyFactory {
    public CompanyFluent Create(string name) {
        return new CompanyFluent(name);
    }
}