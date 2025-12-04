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
public Task<IEnumerable<EventsDao?>> GetAllEventsAsync()
    {
        throw new NotImplementedException();
    }
    public Task<EventsDao?> GetEventByIdAsync(int id){
        throw new NotImplementedException();
    }
    public Task<int> AddEventAsync(EventsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> UpdateEventAsync(EventsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> DeleteEventAsync(int id){
        throw new NotImplementedException();
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
    public Task<IEnumerable<AppointmentsDao?>> GetAllAppointmentsAsync(){
        throw new NotImplementedException();
    }
    public Task<AppointmentsDao?> GetAppointmentByIdAsync(int id){
        throw new NotImplementedException();
    }
    public Task<int> AddAppointmentAsync(AppointmentsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> UpdateAppointmentAsync(AppointmentsDao entity){
        throw new NotImplementedException();
    }
    public Task<bool> DeleteAppointmentAsync(int id){
        throw new NotImplementedException();
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
    public Task<PaymentsDao?> GetPaymentByReferenceAsync(string referenceId){
        throw new NotImplementedException();
    }

    //PaymentTicket
   public Task LinkPaymentToTicketAsync(int paymentId, int ticketId){
       throw new NotImplementedException();
   }
   //payment appointment
    public Task LinkPaymentToAppointmentAsync(int paymentId, int appointmentId){
        throw new NotImplementedException();
    }
}
