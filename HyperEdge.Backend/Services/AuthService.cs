using System;
using AutoMapper; 
using EasyCaching.Core;
using MagicOnion;
using MagicOnion.Server;
using Microsoft.AspNetCore.Authorization;

using HyperEdge.Shared.Protocol;
using HyperEdge.Shared.Services;
using HyperEdge.Backend.Auth;
using HyperEdge.Backend.Db;
using HyperEdge.Backend.Db.Models;
using HyperEdge.Backend.Errors;


namespace HyperEdge.Backend.Services
{
    [Authorize]
    public class AuthService : ServiceBase<IAuthService>, IAuthService
    {
        private readonly IDbContext _db;
        private readonly JwtTokenService _jwtTokenService;
        private readonly ChallengeService _challengeService;

        public AuthService(
            IDbContext db,
            JwtTokenService jwtTokenService,
            ChallengeService challengeService)
        {
            this._db = db ?? throw new ArgumentNullException(nameof(db));
            this._jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
            this._challengeService = challengeService ?? throw new ArgumentNullException(nameof(challengeService));
        }

        [AllowAnonymous]
        public async UnaryResult<GetChallengeResponse> GetChallengeAsync(GetChallengeRequest req)
        {
            /*
            var userModel = await _db.Users.FindByIdAsync(req.UserId);
            if (userModel is null)
            {
                throw GeneralErrors.UserNotFound(req.UserId);
            }
            */
            //var challenge = await _challengeService.NewChallenge(userModel.Id, accModel.Address);
            return new GetChallengeResponse { Challenge = "xxxx" };//challenge };
        }

        [AllowAnonymous]
        public async UnaryResult<ValidateChallengeResponse> ValidateAsync(ValidateChallengeRequest req)
        {
            /*
            var verifResult = await _challengeService.VerifyChallenge(req.UserId, req.Signature);
            if (!verifResult)
            {
                return ValidateChallengeResponse.Failed;
            }
            */
            var (token, expires) = _jwtTokenService.CreateToken(req.UserId.ToString());
            return new ValidateChallengeResponse(token, expires);
        }
    }
}
