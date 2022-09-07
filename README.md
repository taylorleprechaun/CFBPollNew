# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS) !!!!!!!!!!!

### Recent changes

* 9/6/2022: Updates to score prediction algorithm to smooth out early season data (the file that does this is excluded from the repo but I did make changes to it)

### Rankings (Updated 9/6/2022)

**Week 2 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Alabama | 1.0000 | 1-0
2 | Georgia | 0.9469 | 1-0
3 | Michigan | 0.9051 | 1-0
4 | Oklahoma State | 0.9028 | 1-0
5 | Ohio State | 0.8911 | 1-0
6 | Michigan State | 0.8878 | 1-0
7 | Mississippi | 0.8645 | 1-0
8 | Clemson | 0.8615 | 1-0
9 | Pittsburgh | 0.8558 | 1-0
10 | Arkansas | 0.8474 | 1-0
11 | Oklahoma | 0.8470 | 1-0
12 | Kentucky | 0.8441 | 1-0
13 | Brigham Young | 0.8383 | 1-0
14 | Houston | 0.8364 | 1-0
15 | SMU | 0.8357 | 1-0
16 | North Carolina State | 0.8355 | 1-0
17 | Minnesota | 0.8259 | 1-0
18 | James Madison | 0.8216 | 1-0
19 | Tennessee | 0.8125 | 1-0
20 | Northwestern | 0.8081 | 1-0
21 | UCLA | 0.8022 | 1-0
22 | Coastal Carolina | 0.8013 | 1-0
23 | Penn State | 0.7998 | 1-0
24 | Utah State | 0.7954 | 1-1
25 | Mississippi State | 0.7939 | 1-0

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2022/2022-Week%2002.md)

#### Observations and Notes (Updated 9/6/2022)

* Football is back! Go Gata!
* I use the previous season results for the first few weeks of the season so the rankings at first are less chaotic. Seems like it's working pretty well so far this year. James Madison obviously doesn't have a previous year to use so they're a bit of an outlier but I'm sure will normalize over time

#### Predictions (Updated 9/6/2022)

Week 2 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2022/Predictions/2022-Week%2002.md)

When I ran this this week I realized my predictions algorithm was *horribly* flawed and was causing some hilarious results (like Arkansas State beating Ohio State 55-13 lol). I spent like an hour modifying it similar-ish-ly to how I adjust the rating algorithm in the early weeks of the season.

### TODO List (Updated 10/24/2021)

1. Automate results of weekly predictions

2. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it.  I have some ideas for tweaks but for this season it's good enough.

3. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

4. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
5. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

6. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2021 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them (here: https://github.com/taylorleprechaun/CFBPollNew/blob/master/rsc/teams/BOAT%20and%20WOAT.xlsx )

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.

*New additions for the 2021 season!*

* This year Georgia clocks in with a 40.359 in my poll, placing them at #8 in the Playoff Era
* No teams had a rating less than 16.  So no new additions.  The worst team of the season was FIU with a rating of 16.036

**The top 5 Best of all Time (pre-CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2001 | Miami FL | 42.309 | 12-0
2 | 2009 | Alabama | 41.756 | 14-0
3 | 2010 | Auburn | 41.464 | 14-0
4 | 2005 | Texas | 41.291 | 13-0
5 | 2000 | Oklahoma | 41.246 | 13-0

**The top 5 Best of all Time (CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2018 | Clemson | 42.445 | 15-0
2 | 2019 | LSU | 42.374 | 15-0
3 | 2015 | Alabama | 41.615 | 14-1
4 | 2016 | Alabama | 41.061 | 14-1
5 | 2016 | Clemson | 41.044 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
