using AutoMapper;
using ECommerce.Ploto.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Application.Commands.User.UpsertUserAvater
{
    public class UpsertUserAvaterCommandHandler : IRequestHandler<UpsertUserAvatarCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpsertUserAvaterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpsertUserAvatarCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository
                .FindAsync(cancellationToken: cancellationToken,
                           predicate: x => x.Id == request.userId,
                           orderBy: null,
                           include: x => x.Avatar);


            upsertAvatar();

            await _unitOfWork.SaveChangeAsync();


            void upsertAvatar()
            {
                var singleUser = user.Single();


                if (singleUser.Avatar is not null)
                    singleUser.UpdateAvatar(request.avater);

                if (singleUser.Avatar is null)
                    singleUser.AddAvatar(request.avater);

            }

        }
    }
}
