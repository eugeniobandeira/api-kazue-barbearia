using Kazue.Application.Adapter.User;
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Request.User;
using Kazue.Domain.Response.Shared;
using Kazue.Domain.Response.User;

namespace Kazue.Application.UseCases.User.Get;

public class GetUserUseCase : IGetUserUseCase
{
    private readonly IReadUserRepository _readUserRepository;

    public GetUserUseCase(IReadUserRepository readUserRepository)
    {
        _readUserRepository = readUserRepository;
    }

    public async Task<ListApiResponse<UserResponse>> ExecuteAsync(GetUserRequest req)
    {
        ListApiResponse<UserResponse> apiResponse = new();

        var listApiResponse = await _readUserRepository.GetAll(req);

        if (listApiResponse.Count != 0)
        {
            foreach (var response in listApiResponse)
            {
                var user = UserAdapter.FromEntityToResponse(response);
                apiResponse.Response.Add(user);
            }
        }

        apiResponse.ResultCount = listApiResponse.Count();
        apiResponse.RowsCount = listApiResponse.First().QT_RECORDS;

        return apiResponse;
    }
}
