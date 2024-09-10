# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/2/2024: Merged in start of some UI changes which I haven't worked on in idk like 8 months. Also made some fixes to typical early season issues due to incomplete/missing data.
* 9/3/2024: Slight adjustments to Predictions algorithm. Small code adjustments to improve the experience of running everything.

### Rankings (Updated 9/8/2024)

**Week 3 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Washington | 1.0000 | 2-0
2 | Georgia | 0.9959 | 2-0
3 | Alabama | 0.9892 | 2-0
4 | Texas | 0.9818 | 2-0
5 | Ohio State | 0.9776 | 2-0
6 | Mississippi | 0.9768 | 2-0
7 | Missouri | 0.9728 | 2-0
8 | Oregon | 0.9556 | 2-0
9 | Penn State | 0.9483 | 2-0
10 | Oklahoma | 0.9361 | 2-0
11 | Louisville | 0.9212 | 2-0
12 | Tennessee | 0.9188 | 2-0
13 | Kansas State | 0.9180 | 2-0
14 | Arizona | 0.9133 | 2-0
15 | Oklahoma State | 0.9047 | 2-0
16 | Liberty | 0.9011 | 2-0
17 | James Madison | 0.8970 | 2-0
18 | Utah | 0.8887 | 2-0
19 | USC | 0.8874 | 2-0
20 | Duke | 0.8856 | 2-0
21 | Memphis | 0.8837 | 2-0
22 | Miami FL | 0.8796 | 2-0
23 | Oregon State | 0.8788 | 2-0
24 | Iowa State | 0.8754 | 2-0
25 | Rutgers | 0.8718 | 2-0

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/2024-Week%2003.md)

#### Observations and Notes (Updated 9/8/2024)

* My poll does some adjustments to early season lack of data by adjusting it using the previous season and progressively decreases that adjustment factor as the data points expand. Washington is getting heavily boosted by this it's actually kind of annoying. I've had in my TODO list for a few years something to adjust early season ratings by recruiting, returning production, etc. but maybe I should put some gas on that for next offseason to avoid stuff like this. Not totally sure how I want to approach that yet or if I do at all. Regardless, everything will shake out in the next couple weeks.

#### Predictions (Updated 9/10/2024)

Week 3 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2003.md)

Week 2 Results: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2002.md)

Week 2 Results:
* Winner: 31 - 18 (63.3%)
* ATS: 25 - 24 (51.0%)
* O/U: 26 - 23 (53.1%)

Season Results:
* Winner: 31 - 18 (63.3%)
* ATS: 25 - 24 (51.0%)
* O/U: 26 - 23 (53.1%)

2023 Season Results:
* Winner: 507 - 232 (68.6%)
* ATS: 365 - 374 (49.4%)
* O/U: 366 - 373 (49.5%)

2022 Season Results:
* Winner: 485 - 240 (66.9%)
* ATS: 341 - 383 (47.1%)
* O/U: 372 - 352 (51.4%)

### TODO List (Updated 12/5/2023)

1. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it. I found a [site](https://www.thepredictiontracker.com/ncaaresults.php) posted on r/CFB with the results of a bunch of predictive algorithms so I'll definitely use this as some benchmarks when updating my algorithm. As of writing this my outright picks are on the low end, my ATS picks are middle of the pack, and my RMSE is really really bad lol.

2. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

3. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
4. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

5. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2022 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.
I'm probably going to have to split the CFP era into 4 and 12 team sections but that's a problem for future me

*New additions for the 2023 season!*

* This year Michigan clocks in with a 42.244 in my poll, placing them at #3 in the Playoff Era
* This year Kent State clocks in with a 15.812 in my poll, placing them at 11th worst in the Playoff Era

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
3 | 2022 | Michigan | 42.244 | 15-0
4 | 2022 | Georgia | 42.124 | 15-0
5 | 2015 | Alabama | 41.615 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
