namespace Feed.Application.Exceptions;

public class AlreadyExist(string name, string key) : Exception($"{name} with {key} already exists.") { }
