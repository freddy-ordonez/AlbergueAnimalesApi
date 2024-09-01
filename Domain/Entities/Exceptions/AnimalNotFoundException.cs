namespace Domain.Entities.Exceptions
{
    public class AnimalNotFoundException : NotFoundException
    {
        public AnimalNotFoundException(Guid animalId) : base($"The animal whit id: {animalId} doesn't exist in the database.")
        {
        }
    }
}