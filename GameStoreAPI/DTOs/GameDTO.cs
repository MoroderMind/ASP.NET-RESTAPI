namespace GameStoreAPI.DTOs;

public record class GameDTO(
    int Id, 
    string Name, 
    string Genre, 
    decimal price,
    DateOnly ReleaseDate);
