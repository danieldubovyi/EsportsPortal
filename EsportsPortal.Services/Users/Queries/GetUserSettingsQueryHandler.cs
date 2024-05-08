﻿using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Users;
using EsportsPortal.Services.Users.Dto;
using MediatR;

namespace EsportsPortal.Services.Users.Queries;
public record GetUserSettingsQuery(string UserId) : IRequest<IReadOnlyCollection<UserSettingItem>>;

internal class GetUserSettingsQueryHandler(IEntityRepository<UserSetting> settingRepository)
    : IRequestHandler<GetUserSettingsQuery, IReadOnlyCollection<UserSettingItem>>
{
    public async Task<IReadOnlyCollection<UserSettingItem>> Handle(GetUserSettingsQuery request, CancellationToken cancellationToken)
    {
        return await settingRepository.GetProjectedListAsync(
            s => s.UserId == request.UserId,
            s => new UserSettingItem(s.Name, s.Value),
            cancellationToken);
    }
}
