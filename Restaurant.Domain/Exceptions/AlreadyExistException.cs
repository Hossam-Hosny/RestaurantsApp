namespace Restaurant.Domain.Exceptions;

public class AlreadyExistException(string resourceType , string resourceIdentifier,string supEntityType, string supEntityName):Exception($"{resourceType} with id: {resourceIdentifier} alread have {supEntityName} {supEntityType} in {supEntityType}s!")
{
}
