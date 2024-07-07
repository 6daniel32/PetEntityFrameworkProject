public class CompanyFactory {
    public Company Create(string name) {
        return new Company(name);
    }
}