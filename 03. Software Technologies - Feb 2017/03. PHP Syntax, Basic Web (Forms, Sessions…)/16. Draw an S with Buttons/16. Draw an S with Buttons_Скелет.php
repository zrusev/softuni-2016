<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<?php
    $arr = [
        [1, 1, 1, 1, 1],
        [1, 0, 0, 0, 0],
        [1, 0, 0, 0, 0],
        [1, 0, 0, 0, 0],
        [1, 1, 1, 1, 1],
        [0, 0, 0, 0, 1],
        [0, 0, 0, 0, 1],
        [0, 0, 0, 0, 1],
        [1, 1, 1, 1, 1]
    ];

    for ($row = 0; $row < 9; $row++)
    {
        for ($col = 0; $col < 5; $col++)
        {
            $currentElement = $arr[$row][$col];

            if($currentElement == 1)
            {
                echo "<button style='background-color: blue'>$currentElement</button>";
            }
            else
            {
                echo "<button>$currentElement</button>";
            }
        }
        echo "<br/>";
    }


?>
</body>
</html>