<?php  
$dbhost = "localhost";
$dbuser = "root";
$dbpass = "";
$dbname = "sin_Keylogger";

$conexion = mysql_connect($dbhost, $dbuser, $dbpass, $dbname);
if (!$conexion) 
{
	die("No hay conexión: ".mysqli_connect_error());
}
$nombre = $S_POST["txtusuarios"];
$pass = $S_POST["txtpassword"];

$query = mysql_query($conexion,"SELECT * FROM login WHERE usuario = '".$nombre."' and password = '".$pass."'");
$nr = mysqli_num_rows($query);

if ($nr == 1) 
{
	//header ("Location: pagina.html")
	echo "Bienvenido: " .$nombre;
}
elseif ($nr == 0) 
{
	echo "Ingreso denegado, usuarios no existente";
}

?>