
namespace Default.Web.Test.Automation.Entities
{
    public class TestData
    {
        public string firstname;
        public string lastname;

        //LoginPage Test Data
        public string executionSteps;
        public string UserName;
        public string password;
        public string errorMessage;
        public string testCaseName;
        public string validateDBValues;
        public string methodName;

        //Reset Password Test data
        public string NewPassword;
        public string ConfirmPassword;
        public string ExecutionSteps;

        //Organization Details Test Data
        public string OrganizationName { get; set; }
        public string OrganizationAddress1;
        public string OrganizationAddress2;
        public string Zipcode;
        public string City;
        public string State;

        //Primary Contact Details Test Data
        public string PrimaryFirstName { get; set; }
        public string PrimaryLastName { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryPhone { get; set; }

        //Secondary Contact Details Test Data
        public string SecondaryFirstName { get; set; }
        public string SecondaryLastName { get; set; }
        public string SecondaryEmail { get; set; }
        public string SecondaryPhone { get; set; }

        //Billing Contact Details Test Data
        public string BillingFirstName { get; set; }
        public string BillingLastName { get; set; }
        public string BillingEmail { get; set; }
        public string BillingPhone { get; set; }

        //Licenses Details Test Data
        public string UserLicense;
        public string FileLicense;
        public string StorageLicense;
        public string Features;

        //Deactivate Details Test Data
        public string DeactivateReason { get; set; }
        public string ReactivateReason { get; set; }

        public string UIActiveOrganizationCount;

        //Mail Data Capture Test Data
        public string MailingDate { get; set; }
        public string MailDescription { get; set; }
        public string MailType { get; set; }
        public string MailService { get; set; }
        public string MailEnclosure { get; set; }
        public string MailingId { get; set; }
        public string DocumentName { get; set; }
        public string Banner { get; set; }
        public string RetainDocument { get; set; }
        public string SelectAll { get; set; }
        public string ReferenceNumber { get; set; }
        public string SentTo { get; set; }
        public string PaginationCount { get; set; }
        public string RecipientCount { get; set; }
        public string CertifiedNumber { get; set; }
        public string UploadDocumentCount { get; set; }
        public string Id { get; set; }
        public string BarCodeNumber { get; set; }
        public string MailValidationCount { get; set; }
        public int docListLength { get; set; }
        public int recipientListLength { get; set; }








        //User Details User_Admin Test Data
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone { get; set; }
        public string CEmail { get; set; }
        public string Email { get; set; }
        public string sample { get; set; }
        public string TemporaryPassword { get; set; }
        public string AddedFeaturesList { get; set; }

        //Event Test Data
        public string EventCode { get; set; }
        public string EventName { get; set; }
        public string Milestone { get; set; }
        public string SearchMilestone { get; set; }

        public string ModifiedName { get; set; }
        public string PageCount { get; set; }
        public string Name { get; set; }
        public string Filters { get; set; }
        public string ShowActiveEvents { get; set; }
        public string EventState { get; set; }

        //Event Template Test Data

        public string TemplateCode { get; set;}
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string IsPrimaryEvent { get; set; }
        public string totalAvailableItems { get; set; }





    }
}
