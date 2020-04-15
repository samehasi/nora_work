

#Action of connecting to the Database and executing the query and returning results if there were any.
$conn=New-Object System.Data.SqlClient.SQLConnection
$db_path = "d:\work\Nora\workspace\nora_work\Garage\Garage.mdf"
$connectionString = "Data Source=.\SQLExpress;Integrated Security=true; AttachDbFilename=$db_path;User Instance=true"

$Query = "select * from [dbo].[user]"


$conn.ConnectionString=$ConnectionString
$conn.Open()


$sqltoexecute = Get-Content("d:\work\Nora\workspace\nora_work\Garage\DBScripts\FillDb.sql");

$cmd=New-Object system.Data.SqlClient.SqlCommand($sqltoexecute,$conn)
$cmd.CommandTimeout=$QueryTimeout
$ds=New-Object system.Data.DataSet
$da=New-Object system.Data.SqlClient.SqlDataAdapter($cmd)
[void]$da.fill($ds)
$conn.Close()
$ds.Tables