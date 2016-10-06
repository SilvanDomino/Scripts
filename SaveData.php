<?php
  $score=$_REQUEST['score'];

  //sanitize input

  if($score != ""){
    $database = mysqli_connect('localhost', 'Student', 'NicCage', 'hers_myRunner') or die('Failed to connect: ' . mysql_error());
    $timeStamp = date('Y-m-d H:i:s');
    $query="INSERT INTO HighScores(ID, Score) VALUES(DEFAULT, '$score');";
    $result=mysqli_query($query);
    echo "$score, $playerID, $timeStamp success?";
  } else{
    echo "Bro score was empty bro";
  }

 ?>
