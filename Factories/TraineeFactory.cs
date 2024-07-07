public class TraineeFactory {
    public Trainee Create(string name, Company company) {
        /* This syntax is known as "property initialization".
         * It allows to create the object with its required 
         * fields and set an object property afterwards when
         * providing the property to the constructor could be 
         * problematic. For instance: constructors which only
         * accept simple types, this is the case for EF Core models*/
        return new Trainee(name) {
            Company = company
        };
    }
}