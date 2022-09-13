# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS) !!!!!!!!!!!

### Recent changes

* 9/6/2022: Updates to score prediction algorithm to smooth out early season data (the file that does this is excluded from the repo but I did make changes to it)

### Rankings (Updated 9/12/2022)

**Week 3 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Georgia | 1.0000 | 2-0
2 | Mississippi | 0.9446 | 2-0
3 | Clemson | 0.9335 | 2-0
4 | Louisiana-Lafayette | 0.9211 | 2-0
5 | Michigan State | 0.9137 | 2-0
6 | Brigham Young | 0.9098 | 2-0
7 | Alabama | 0.9031 | 2-0
8 | Wake Forest | 0.9009 | 2-0
9 | Kentucky | 0.8984 | 2-0
10 | Oklahoma State | 0.8962 | 2-0
11 | Baylor | 0.8901 | 1-1
12 | Ohio State | 0.8895 | 2-0
13 | Iowa State | 0.8883 | 2-0
14 | North Carolina State | 0.8881 | 2-0
15 | James Madison | 0.8851 | 2-0
16 | Arkansas | 0.8807 | 2-0
17 | Auburn | 0.8777 | 2-0
18 | Cincinnati | 0.8754 | 1-1
19 | Penn State | 0.8718 | 2-0
20 | SMU | 0.8711 | 2-0
21 | Kansas State | 0.8694 | 2-0
22 | Washington State | 0.8655 | 2-0
23 | Florida State | 0.8500 | 2-0
24 | Texas Tech | 0.8460 | 2-0
25 | Oregon State | 0.8458 | 2-0

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2022/2022-Week%2003.md)

#### Observations and Notes (Updated 9/12/2022)

* This week is kind of funky. I've been really busy with a huge project at work the last couple months so I don't have a ton of time to look at the data that's driving this rankings. I'll need to revisit this when I have more time to see what's going on because it seems like my early season adjustments in the rating formula aren't applying as I'd expect

#### Predictions (Updated 9/12/2022)

Week 3 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2022/Predictions/2022-Week%2003.md)

Week 2 Results [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2022/Predictions/2022-Week%2002.md) (I really need to automate this btw this took me like 2 hours to fill in the results manually lol):
* Winner: 33 - 16
* ATS: 26 - 23
* O/U: 25 - 24

Season Results:
* Winner: 33 - 16
* ATS: 26 - 23
* O/U: 25 - 24
 
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
