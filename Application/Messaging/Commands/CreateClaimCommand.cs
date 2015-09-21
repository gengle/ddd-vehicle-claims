using System;
using Application.Services;
using Core;
using Domain;

namespace Application.Messaging.Commands
{
    public class CreateClaimCommand : ICommand
    {
        public string Id { get; set; }
        public string PolicyNo { get; set; }

        public static string NewId()
        {
            return ClaimId.NewId().ToString();
        }
    }
}