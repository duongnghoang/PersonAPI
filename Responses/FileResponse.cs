namespace PersonAPI.Responses;
public class FileResponse
{
    public byte[] FileContent { get; set; }
    public string ContentType { get; set; }
    public string FileName { get; set; }
    public FileResponse(byte[] fileContent, string contentType, string fileName)
    {
        FileContent = fileContent;
        ContentType = contentType;
        FileName = fileName;
    }
}