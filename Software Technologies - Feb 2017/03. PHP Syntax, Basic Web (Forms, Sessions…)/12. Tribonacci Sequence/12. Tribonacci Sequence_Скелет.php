<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
    if(isset($_GET['num']))
    {
        $n = intval($_GET['num']);

        $x = 0;
        $y = 1;
        $yy = 1;
        echo 1 . ' ';
        echo 1 . ' ';
        for($i = 0 ;$i < $n - 2; $i++)
        {
            $z = $x + $y + $yy;

            echo $z. ' ';
            $x=$y;
            $y=$yy;
            $yy=$z;
        }

    }
    ?>
</body>
</html>