using System.Data;
using Dapper;

namespace Tunination;

public class TutinationRepo : ITutination
{
    private readonly IDbConnection db;

    public TutinationRepo(IDbConnection dbConnection)
    {
        db = dbConnection;
    
    }
    
   //user 
  public Task<IEnumerable<UsersDao?>> GetAllAsync(){
      string query = @"SELECT * FROM Users";

    return  db.QueryAsync<UsersDao?>(query);
   }
   public async Task<UsersDao?> GetByIdAsync(int id){
       string query = @"SELECT * FROM Users WHERE UserID = @Id";

        return await db.QuerySingleOrDefaultAsync<UsersDao?>(query, new { Id = id });
   }
 public async Task<int> AddAsync(UsersDao entity)
{
    string query = @"
        INSERT INTO Users (FullName, Email, PhoneNumber, PasswordHash, Role, DateRegistered)
        VALUES (@FullName, @Email, @PhoneNumber, @PasswordHash, @Role, @DateRegistered);

        SELECT CAST(SCOPE_IDENTITY() AS INT);
    ";

    return await db.ExecuteScalarAsync<int>(query, entity);
}

   public async Task<bool> UpdateAsync(UsersDao entity){
         string query = @"
        UPDATE Users
        SET FullName = @FullName,
            Email = @Email,
            PhoneNumber = @PhoneNumber,
            PasswordHash = @PasswordHash,
            Role = @Role,
            DateRegistered = @DateRegistered
        WHERE UserID = @UserID;
    ";

    int rowsAffected = await db.ExecuteAsync(query, entity);
    return rowsAffected > 0;
   }
   public async Task<bool> DeleteAsync(int id){
       string query = @"DELETE FROM Users WHERE UserID = @Id";
       int rowsAffected = await db.ExecuteAsync(query, new { Id = id });
       return rowsAffected > 0;
   }

   public async Task<UsersDao?> GetByEmailAsync(string email){
       string query = @"SELECT * FROM Users WHERE Email = @Email";
       return await db.QuerySingleOrDefaultAsync<UsersDao?>(query, new { Email = email });
   }
   public async Task<bool> CheckEmailExistsAsync(string email){
       string query = @"SELECT COUNT(1) FROM Users WHERE Email = @Email";
       int count = await db.ExecuteScalarAsync<int>(query, new { Email = email });
       return count > 0;
   }


//event
public async Task<IEnumerable<EventsDao?>> GetAllEventsAsync()
    {
         string query = @"
        SELECT 
            EventID,
            Title,
            Description,
            Location,
            StartDate,
            EndDate,
            Price,
            Capacity,
            RemainingCapacity,
            Image AS ImageBytes,
            PaymentLink
        FROM Events
        ORDER BY StartDate ASC;
    ";

    return await  db.QueryAsync<EventsDao?>(query);
}

    public Task<EventsDao?> GetEventByIdAsync(int id){
        throw new NotImplementedException();
    }
    public async Task<int> AddEventAsync(EventsDao entity)
    {
          string query = @"
        INSERT INTO Events (
            Title,
            Description,
            Location,
            StartDate,
            EndDate,
            Price,
            Capacity,
            RemainingCapacity,
            Image,
            PaymentLink
        )
        VALUES (
            @Title,
            @Description,
            @Location,
            @StartDate,
            @EndDate,
            @Price,
            @Capacity,
            @RemainingCapacity,
            @ImageBytes,
            @PaymentLink
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT);
    ";

    return await db.ExecuteScalarAsync<int>(query, entity);
}

    public Task<bool> UpdateEventAsync(EventsDao entity){
        throw new NotImplementedException();
    }
    public async Task<bool> DeleteEventAsync(int id){
        string query = @"DELETE FROM Events WHERE EventID = @Id";
        int rowsAffected = await db.ExecuteAsync(query, new { Id = id });
        return rowsAffected > 0;
    }

//tickets
    public Task<IEnumerable<TicketsDao?>> GetAllTicketsAsync(){
        throw new NotImplementedException();
    }
    public Task<TicketsDao?> GetTicketByIdAsync(int id){
        throw new NotImplementedException();
    }
    public Task<int> AddTicketAsync(TicketsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> UpdateTicketAsync(TicketsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> DeleteTicketAsync(int id){
        throw new NotImplementedException();
    }
    public Task<IEnumerable<TicketsDao?>> GetTicketsByUserAsync(int userId){
        throw new NotImplementedException();
    }
    public Task<IEnumerable<TicketsDao?>> GetTicketsByEventAsync(int eventId){
        throw new NotImplementedException();
    }
    //services
    public Task<IEnumerable<ServicesDao?>> GetAllServicesAsync(){
        throw new NotImplementedException();
    }
    public Task<ServicesDao?> GetServiceByIdAsync(int id){
        throw new NotImplementedException();
    }
    public Task<int> AddServiceAsync(ServicesDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> UpdateServiceAsync(ServicesDao entity){
        throw new NotImplementedException();
    }
   public Task<bool> DeleteServiceAsync(int id){
       throw new NotImplementedException();
   }

//apppointments
    public async Task<IEnumerable<AppointmentsDao?>> GetAllAppointmentsAsync(){
       string query = @"
        SELECT 
            AppointmentID,
            UserID,
            AppointmentDate,
            StartTime,
            EndTime,
            Status,
            Notes,
            ServiceType
        FROM Appointments;
    ";
    return await db.QueryAsync<AppointmentsDao>(query);

    }
    public Task<AppointmentsDao?> GetAppointmentByIdAsync(int id)
    {
        string query = @"
        SELECT 
            AppointmentID,
            UserID,
            ServiceType,
            AppointmentDate,
            StartTime,
            EndTime,
            Status,
            Notes
        FROM Appointments
        WHERE AppointmentID = @Id;
    ";
        return db.QuerySingleOrDefaultAsync<AppointmentsDao?>(query, new { Id = id });
        
    }
    public async Task<int> AddAppointmentAsync(AppointmentsDao entity)
    {
         string query = @"
        INSERT INTO Appointments (
            UserID,
            ServiceType,
            AppointmentDate,
            StartTime,
            EndTime,
            Status,
            Notes
        )
        VALUES (
            @UserID,
            @ServiceType,
            @AppointmentDate,
            @StartTime,
            @EndTime,
            @Status,
            @Notes
        );

        SELECT CAST(SCOPE_IDENTITY() AS INT);
    ";

    return await db.ExecuteScalarAsync<int>(query, entity);
        
    }
    public async Task<bool> UpdateAppointmentAsync(AppointmentsDao entity){
        string query = @"
        UPDATE Appointments
        SET 
            ServiceType = @ServiceType,
            AppointmentDate = @AppointmentDate,
            StartTime = @StartTime,
            EndTime = @EndTime,
            Status = @Status,
            Notes = @Notes
        WHERE AppointmentID = @AppointmentID;
    ";

    int rowsAffected = await db.ExecuteAsync(query, entity);
    return rowsAffected > 0;
}

    public  async Task<bool> DeleteAppointmentAsync(int id)
    {
         string query = @"DELETE FROM Appointments WHERE AppointmentID = @Id";
       var rowsAffected = await db.ExecuteAsync(query, new { Id = id });
       return rowsAffected >0;
        
    }
    public Task<IEnumerable<PaymentsDao?>> GetPaymentsByUserAsync(int userId){
        throw new NotImplementedException();
    }
//payments
    public Task<IEnumerable<PaymentsDao?>> GetAllPaymentsAsync(){
        throw new NotImplementedException();
    }
    public Task<PaymentsDao?> GetPaymentByIdAsync(int id){
        throw new NotImplementedException();
    }
    public Task<int> AddPaymentAsync(PaymentsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> UpdatePaymentAsync(PaymentsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> DeletePaymentAsync(int id){
        throw new NotImplementedException();
    }

public async Task<IEnumerable<PaymentTicketDao?>>  GetAllPaymentByReferenceAsync()
{
    var query = @"
        SELECT
            PaymentID,
            UserID,
            EventID,
            Amount,
            Currency,
            PaymentDate,
            PaymentStatus
        FROM PaymentTickets
        ORDER BY PaymentDate DESC
    ";

    return await db.QueryAsync<PaymentTicketDao>(query);
}

    //PaymentTicket
 public async Task AddPaymentReferenceAsync(PaymentTicketDao dto)
{
    var query = @"
        INSERT INTO PaymentTickets
        (
            UserID,
            EventID,
            Amount,
            Currency,
            PaymentDate,
            PaymentStatus
        )
        VALUES
        (
            @UserID,
            @EventID,
            @Amount,
            @Currency,
            @PaymentDate,
            @PaymentStatus
        );";

    await db.ExecuteAsync(query, new
    {
        dto.UserID,
        dto.EventID,
        dto.Amount,
        dto.Currency,
        dto.PaymentDate,
        dto.PaymentStatus
    });
}

public async Task<bool> UpdatePaymentReferenceAsync(int PaymentId, string status)
{
    var query = @"
        UPDATE PaymentTickets
        SET PaymentStatus = @PaymentStatus
        WHERE PaymentID = @PaymentID
    ";

    var rows = await db.ExecuteAsync(query, new
    {
        PaymentID = PaymentId,
        PaymentStatus = status
    });

    return rows > 0;
}

//add paymentlink  to user 
public async Task AddPaymentLinksAsync(PaymentLinksDao entity)
{
    var query = @"
        INSERT INTO PaymentLinks (
            PodcastPaymentLink, 
            StudioPaymentLink
        )
        VALUES (@PodcastPaymentLink, @StudioPaymentLink)";
    
    await db.ExecuteAsync(query, entity);
}
public async Task<PaymentLinksDao?> GetPaymentLinksByIdAsync(int id)
{
    var query = @"SELECT * FROM PaymentLinks WHERE Id = @Id";
    return await db.QueryFirstOrDefaultAsync<PaymentLinksDao>(query, new { Id = id });
}

public async Task<bool> UpdatePodcastPaymentLinkAsync(int id, string newLink)
{
    var query = @"
        UPDATE PaymentLinks
        SET PodcastPaymentLink = @Link,
            UpdatedAt = GETDATE()
        WHERE Id = @Id";

    var rows = await db.ExecuteAsync(query, new { Id = id, Link = newLink });
    return rows > 0;
}


public async Task<bool> UpdateStudioPaymentLinkAsync(int id, string newLink)
{
    var query = @"
        UPDATE PaymentLinks
        SET StudioPaymentLink = @Link,
            UpdatedAt = GETDATE()
        WHERE Id = @Id";

    var rows = await db.ExecuteAsync(query, new { Id = id, Link = newLink });
    return rows > 0;
}
public async Task<bool> DeletePodcastPaymentLinkAsync(int id)
{
    var query = @"
        UPDATE PaymentLinks
        SET PodcastPaymentLink = NULL,
            UpdatedAt = GETDATE()
        WHERE Id = @Id";

    return await db.ExecuteAsync(query, new { Id = id }) > 0;
}

public async Task<bool> DeleteStudioPaymentLinkAsync(int id)
{
    var query = @"
        UPDATE PaymentLinks
        SET StudioPaymentLink = NULL,
            UpdatedAt = GETDATE()
        WHERE Id = @Id";

    return await db.ExecuteAsync(query, new { Id = id }) > 0;
}

public async Task<string?> GetPodcastPaymentLinkAsync(int id)
{
    var query = @"SELECT PodcastPaymentLink FROM PaymentLinks WHERE Id = @Id";
    return await db.ExecuteScalarAsync<string?>(query, new { Id = id });
}
public async Task<string?> GetStudioPaymentLinkAsync(int id)
{
    var query = @"SELECT StudioPaymentLink FROM PaymentLinks WHERE Id = @Id";
    return await db.ExecuteScalarAsync<string?>(query, new { Id = id });   

}
    public Task<IEnumerable<PaymentLinksDao?>> GetAllPaymentLinksAsync()
    {
        var query = @"SELECT * FROM PaymentLinks";
        return db.QueryAsync<PaymentLinksDao?>(query);
    }

}
 


