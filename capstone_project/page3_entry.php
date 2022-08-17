<?php

$server_name="localhost";
$username="root";
$password="";
$database_name="projectdb";

$conn = mysqli_connect($server_name, $username, $password, $database_name);

if(!$conn){
	exit("Connection Failed: " . mysqli_connect_error());
}

if(isset($_POST['save'])){
	$reason = $_POST['reasons'];
	$body_text = $_POST['bodyTextBox'];

	$report_id = "(COUNT(ReportID_PK) FROM Reports) + 1";
    $sql_query = "INSERT INTO Reports (ReportID_PK, Reason, BodyText, ThreadID_FK)VALUES ('$report_id', '$reason', '$body_text')";


	if(mysqli_query($conn, $sql_query)){
		echo "New application created successfully!";
	} else {
		echo "Error: " . $sql . "" . mysqli_error($conn);
	}
	mysqli_close($conn);
}
?>