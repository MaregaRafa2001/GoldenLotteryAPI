﻿namespace GoldenLotteryAPI.Core
{
    public class Enums
    {
        public enum ESortDirection
        {
            Ascending = 1,
            Descending = 2,
        }

        public enum EGoldenRaffleNumberStatus
        {
            Active = 1,
            Inative = 2,
        }

        public enum EOrderStatus
        {
            Active = 1,
            WaitingPayment = 2,
            Paid = 3,
            Canceled = 4,
        }

        public enum EOrderLogEventTypes
        {
            Created = 1,
            Updated = 2,
        }

        public enum ERaffleStatus
        {
            InProgress = 1,
            Finished = 2,
            Canceled = 3,

        }

        public enum ERaffleCustomerStatus
        {
            Active = 1,
            Inative = 2,
        }

        public enum EUserPolicies
        {
            Customer = 1,
            Administrator = 2,
            Any = 3
        }

        public enum EUserRoles
        {
            Customer = 1,
            Administrator = 2
        }
    }
}
