namespace GameStoreAPI.DTOs;

public record class UpdateGameDTO(
     string Name, 
    string Genre, 
    decimal price,
    DateOnly ReleaseDate);
