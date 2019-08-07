<?php
	$db = mysqli_connect('localhost', 'id1217000_scorehandler', 'score', 'id1217000_raff'); 

    $id = mysqli_real_escape_string($db,  $_GET['id']);
	$operation = mysqli_real_escape_string($db, $_GET['operation']);
    $hash = $_GET['hash']; 
 
    $secretKey="meh";
    $real_hash = md5($id . $operation . $secretKey); 

	if(isset($_GET['coins']))
		$coins =(int) mysqli_real_escape_string($db, $_GET['coins']);
	if(isset($_GET['gems']))
		$gems =(int) mysqli_real_escape_string($db, $_GET['gems']);
	
	if($hash != $real_hash)
	{
	    echo "Unauthorised access!";
	    return;
	}
	
	 switch($operation)
	 {
		 case 0:
			GetCoins();
			break;
	 	 case 1:
			GetGems();
			break;
		 case 2:
			AddCoins();
			break;
		 case 3:
			AddGems();
			break;
		 case 4:
			Register();
			break;
	 }

	 function GetCoins()
	 {
		global $db, $id;
		$q = "select coins from balance where id='" . $id . "';";
		$res = mysqli_query($db, $q)->fetch_assoc();
		$c = $res['coins'];
		echo $c;
	 }
	 function GetGems()
	 {
		global $db, $id;
		$q = "select gems from balance where id='" . $id . "';";
		$res = mysqli_query($db, $q)->fetch_assoc();
		$g = $res['gems'];
		echo $g;
	 }
	 function AddCoins()
	 {
		global $db, $id, $coins;
		if(!isset($coins))
		{
			echo '-2';
			return;
		}

		$q = "select coins from balance where id='" . $id . "';";
		$r = mysqli_query($db, $q)->fetch_assoc();
		$prevCoins = (int) $r['coins'];
		$q = "update balance SET coins=" . ($coins + $prevCoins) . " where id='" . $id . "';";
		$res = mysqli_query($db, $q);
		if($res)
			echo '0';
		else 
			echo '-1';
	 }
	 function AddGems()
	 {
		global $db, $id, $gems;
		if(!isset($gems))
		{
			echo '-2';
			return;
		}

		$q = "select gems from balance where id='" . $id . "';";
		$r = mysqli_query($db, $q)->fetch_assoc();
		$prevGems = (int) $r['gems'];
		$q = "update balance SET gems=" . ($gems + $prevGems) . " where id='" . $id . "';";
		$res = mysqli_query($db, $q);
		if($res)
			echo '0';
		else 
			echo '-1';
	 }
	 function Register()
	 {
		global $db, $id;
		$q = "select * from balance where id='" . $id . "';";
		$result = mysqli_query($db, $q);
		
	    if (!$result)
        {
            die('Error: ' . mysqli_error($db));
        }
		
		if(mysqli_num_rows($result) > 0)
		{
			echo '-1';
			return;
		}else
		{
    		$query = "insert into balance(id, coins, gems) values('" . $id . "', 0, 0);";
    		$res = mysqli_query($db, $query);
    		if($res)
    			echo '0';
    		else
    			echo '-2';
		}
	 }
?>