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
	$first_name = $_POST['firstNameBox'];
	$mid_initial = $_POST['middleInitialBox'];
	$last_name = $_POST['lastNameBox'];
	$suffix = $_POST['suffixBox'];
	$street_address = $_POST['streetAddressBox'];
	$street_address2 = $_POST['streetAddressBox2'];
	$city = $_POST['cityBox'];
	$state_province = $_POST['stateBox'];
	$country = $_POST['countryBox'];
	$zip = $_POST['zipBox'];
	$home_phone = $_POST['homePhoneBox'];
	$work_phone = $_POST['workPhoneBox'];
	$email = $_POST['emailBox'];

	$application_id = "(COUNT(ApplicationID_PK) FROM EmployeeApplications) + 1";
    $sql_query = "INSERT INTO EmployeeApplications (ApplicationID_PK, FirstName, MidInitial, LastName, Suffix,
	StreetAddress, StreetAddress2, City, StateProvince, Country, ZIP, HomePhone, WorkPhone, Email)
	VALUES ('$application_id', '$first_name', '$mid_initial', '$last_name', '$suffix', '$street_address',
	'$street_address2', '$city', '$state_province', '$country', '$zip', '$home_phone', '$work_phone', '$email')";


	if(mysqli_query($conn, $sql_query)){
		echo "New application created successfully!";
	} else {
		echo "Error: " . $sql . "" . mysqli_error($conn);
	}
	mysqli_close($conn);
}
?>