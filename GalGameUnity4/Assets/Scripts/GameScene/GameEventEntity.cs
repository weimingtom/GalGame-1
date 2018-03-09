using System;
using Newtonsoft.Json.Linq;

[System.Serializable]
public class Option{
	public string text;
	public int tag;

	public void FromJSON(JObject jobject)
	{
		{
			JToken textObj = jobject ["text"];
			if (textObj != null) {
				this.text = textObj.ToString ();
			}
		}
		{
			JToken tagObj = jobject ["tag"];
			if (tagObj != null) {
				this.tag = int.Parse (tagObj.ToString ());
			}
		}
	}
}

[System.Serializable]
public class GameEventEntity
{

	public enum EventType{
		Start = 0,
		Option = 1,
		NotOption = 2,
		End = -1
	};

	public int tag;
	public EventType type;
	public string[] characters;
	public string background;
	public string[] textList;

	public Option[] options;

	public int nextTag;

	public int endTag;

	public void FromJSON(JObject jobject)
	{
		{
			JToken tagObj = jobject ["tag"];
			if (tagObj != null) {
				this.tag = int.Parse (tagObj.ToString ());
			}
		}
		{
			JToken typeObj = jobject ["type"];
			if (typeObj != null) {
				this.type = (EventType)int.Parse (typeObj.ToString ());
			}
		}
		{
			JArray charactersList = jobject ["characters"] != null ? (JArray)jobject ["characters"] : null;
			if (charactersList != null) {
				this.characters = new string[charactersList.Count];
				for (int i = 0; i < charactersList.Count; i++) {
					JToken token2 = charactersList [i];
					this.characters [i] = token2.ToString ();
				}
			}
		}
		{
			JToken backgroundObj = jobject ["background"];
			if (backgroundObj != null) {
				this.background = backgroundObj.ToString ();
			}
		}
		{
			JArray textListList = jobject ["textList"] != null ? (JArray)jobject ["textList"] : null;
			if (textListList != null) {
				this.textList = new string[textListList.Count];
				for (int i = 0; i < textListList.Count; i++) {
					JToken token2 = textListList [i];
					this.textList [i] = token2.ToString ();
				}
			}
		}
		{
			JArray optionsList = jobject ["options"] != null ? (JArray)jobject ["options"] : null;
			if (optionsList != null) {
				this.options = new Option[optionsList.Count];
				for (int i = 0; i < optionsList.Count; i++) {
					JObject token2 = (JObject)optionsList [i];
					this.options [i] = new Option ();
					this.options [i].FromJSON (token2);
				}
			}
		}
		{
			JToken nextTagObj = jobject ["nextTag"];
			if (nextTagObj != null) {
				this.nextTag = int.Parse (nextTagObj.ToString ());
			}
		}
		{
			JToken endTagObj = jobject ["endTag"];
			if (endTagObj != null) {
				this.endTag = int.Parse (endTagObj.ToString ());
			}
		}
	}
}


