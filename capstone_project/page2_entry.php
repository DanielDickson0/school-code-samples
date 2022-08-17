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
	$title = $_POST['titleTextBox'];
	$text = $_POST['bodyTextBox'];
	$like_count = 0;
	$dislike_count = 0;
	$vote_count = 0;
	$attachments = $_FILES['attachments'];
	$attachment_name = $attachments['name'];

	$thread_id = "(COUNT(ThreadID_PK) FROM Threads) + 1";
    $sql_query = "INSERT INTO Concepts (ThreadID_FK, Title, BodyText, LikeCount, DislikeCount, VoteCount)
	VALUES ('$thread_id', '$title', '$text', '$like_count', '$dislike_count', '$vote_count')";

	if(mysqli_query($conn, $sql_query)){
		echo "New thread created successfully!";
		
		if (count($attachments != 0)){
			for($i = 0; $i < count($attachments), $i++){
				$attachment_id = "(COUNT(AttachmentID_PK) FROM Attachments) + 1";
				$attachment_status = $attachments(i)->save($path = "./attachments/", $filename = null);
				$attachment_path = "C:/xampp/htdocs/attachments/" + $attachments(i)->name;
				$attachment_query = "INSERT INTO Attachments (AttachmentID_PK, AttachmentLink, ThreadID_FK)
				VALUES ('$attachment_id', '$attachment_path', '$thread_id')";
				if (mysqli_query($conn, $attachment_query)){
					echo "File " . ($i + 1) . " saved successfully!";
				} else {
					echo "Attachment Error: " . $sql . "" . mysqli_error($conn);
				}
			}
		}
	} else {
		echo "Thread Error: " . $sql . "" . mysqli_error($conn);
	}
	mysqli_close($conn);
}
?>