public class CompanyFactory : ICompanyFactory {
    public Company Create(string name) {
        return new Company(name);
    }
}