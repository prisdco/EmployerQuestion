using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceModel.Entities;
using ServiceModel.Model;
using System;

public class QuestionConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Question);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        var questionType = jsonObject["type"].Value<string>();

        Question question;
        switch (questionType)
        {
            case "DropdownQuestion":
                question = new DropdownQuestion();
                break;
            case "ParagraphQuestion":
                question = new ParagraphQuestion();
                break;
            case "NumberQuestion":
                question = new NumberQuestion();
                break;
            case "MultipleChoiceQuestion":
                question = new MultiChoiceQuestion();
                break;
            case "DateQuestion":
                question = new DateQuestion();
                break;
            case "YesNoQuestion":
                question = new YesNoQuestion();
                break;
            default:
                throw new JsonSerializationException($"Unknown question type: {questionType}");
        }

        serializer.Populate(jsonObject.CreateReader(), question);
        return question;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
