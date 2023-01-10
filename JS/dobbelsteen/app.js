class App{
    runApplication(){
        let stat1 = this.rollStat();
        let stat1Header = document.getElementById("stat1");
        stat1Header.innerHTML = stat1;

        let stat2 = this.rollStat();
        let stat2Header = document.getElementById("stat2");
        stat2Header.innerHTML = stat2;

        let stat3 = this.rollStat();
        let stat3Header = document.getElementById("stat3");
        stat3Header.innerHTML = stat3;
        let stat4 = this.rollStat();
        let stat4Header = document.getElementById("stat4");
        stat4Header.innerHTML = stat4;
        let stat5 = this.rollStat();
        let stat5Header = document.getElementById("stat5");
        stat5Header.innerHTML = stat5;
        let stat6 = this.rollStat();
        let stat6Header = document.getElementById("stat6");
        stat6Header.innerHTML = stat6;
        
    }

    rollStat(){
        let dobbelsteen1 = this.rollDice();
        let dobbelsteen2 = this.rollDice();
        let dobbelsteen3 = this.rollDice();
        let dobbelsteen4 = this.rollDice();
        let array = [dobbelsteen1, dobbelsteen2, dobbelsteen3, dobbelsteen4];
        array.sort();
        let som = array[1] + array[2] + array[3];
        return som;
    }

    rollDice(){
        let dice = Math.floor(Math.random() * 6 + 1);
        return dice;
    }
}
let app = new App();
app.runApplication();