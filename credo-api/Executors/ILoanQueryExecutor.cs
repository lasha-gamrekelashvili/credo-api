using credo_client.Responses;

namespace credo_api.Executors;

public interface ILoanQueryExecutor
{
    Task<IEnumerable<GetLoanResponseModel>> GetAllAsync();
    Task<IEnumerable<GetLoanResponseModel>> GetAllByUserIdAsync(Guid userId);

}