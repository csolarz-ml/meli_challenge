using MeLi_Topsecret_split.Domain.Dtos;

namespace MeLi_Topsecret_split.Domain.CommandModel
{
    public class ResponseMessageDto
    {
        public ResponseMessageDto(bool isValid, string errorMessage, MessageDto responseMessageDto)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
            ResponseMessage = responseMessageDto;
        }

        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public MessageDto ResponseMessage { get; set; }
    }
}
