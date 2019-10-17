<?php
  //add ?score=5 to the url
  $score=$_REQUEST['score'];
  $host = 'localhost:8889';
  $user = 'root';
  $password = 'root';
  $database = 'GD2ATD';
  //TODO: Player name?
  //TODO: sanitize input
  //if no score is defined, code won't work
  if($score != ""){
    //connect with database (other user/password combinations may be needed)
    $conn = mysqli_connect($host, $user, $password, $database) or die('Failed to connect: ' . mysqli_error($conn));
    $query="INSERT INTO Scores(id, score, player_name, time) VALUES(DEFAULT, '$score', 'Silvan', DEFAULT);";
    $result=mysqli_query($conn, $query);
    if ($result) {
      echo "New record created successfully";
    } else {
        echo "Error: " . $query . "<br>" . mysqli_error($conn);
    }
  } else{
    echo "Score was empty";
  }
 ?>
