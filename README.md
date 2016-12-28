# SimpleBackup
Simple Backup Tool For Linux, that uses a single configuration file with source and destination.

The tool will default to using config.json or parameters can be passed in for an alternative.  
The real premise here is for an unfamiliar end-user to just execute this and have their contents copied to a drive (backup).

```json
{
  "source": "/tmp/hello",
  "destination": "/tmp/hello2"
}
```

The backup is simplified into the following:

```csharp
private static void backup_data(string source, string destination)
{
            string strCmdText;
            strCmdText = $"-rvf {source} {destination}";
            System.Diagnostics.Process.Start("/bin/cp", strCmdText); 
}
```
